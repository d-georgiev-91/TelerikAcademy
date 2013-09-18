namespace Bookstore.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using ComplexBooksImportFromXmlFile;

    public static class BooksDataAcccessLayer
    {
        public static IList<Review> FindReviewByAuthorName(string authorName)
        {
            var context = new BookstoreEntities();

            var query = (from r in context.Reviews
                         where r.Author.Name.ToLower() == authorName.ToLower()
                         select r).OrderBy(d => d.Date);
            return query.ToList();
        }

        public static IList<Review> FindReviewByPeriod(DateTime startDate, DateTime endDate)
        {
            var context = new BookstoreEntities();

            var query = (from r in context.Reviews
                         where r.Date >= startDate && r.Date <= endDate
                         select r).OrderBy(d => d.Date);
            return query.ToList();
        }

        public static void AddBook(string authorName,
            string title, string isbn, string price, string webSite)
        {
            var context = new BookstoreEntities();
            Book newBook = new Book();
            newBook.Authors.Add(CreateOrLoadAuthor(context, authorName));
            newBook.Title = title;
            newBook.ISBN = isbn;
            newBook.Website = webSite;

            context.Books.Add(newBook);
            context.SaveChanges();
        }

        private static Author CreateOrLoadAuthor(
            BookstoreEntities context, string authorName)
        {
            Author existingAuthor =
                (from a in context.Authors
                 where a.Name.ToLower() == authorName.ToLower()
                 select a).FirstOrDefault();
            if (existingAuthor != null)
            {
                return existingAuthor;
            }

            Author newAuthor = new Author();
            newAuthor.Name = authorName;
            context.Authors.Add(newAuthor);
            return newAuthor;
        }

        public static void AddBook(List<string> authorNames, string title, string isbn, string price, string webSite, List<CustomReview> reviews)
        {
            var context = new BookstoreEntities();
            Book newBook = new Book();

            if (authorNames != null)
            {
                foreach (var authorName in authorNames)
                {
                    newBook.Authors.Add(CreateOrLoadAuthor(context, authorName));
                }
            }

            newBook.Title = title;
            newBook.ISBN = isbn;
            newBook.Website = webSite;

            if (reviews != null)
            {
                foreach (var review in reviews)
                {
                    newBook.Reviews.Add(CreateReview(context, review));
                }
            }

            context.Books.Add(newBook);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var errorMessages = ex.EntityValidationErrors
                                      .SelectMany(x => x.ValidationErrors)
                                      .Select(x => x.ErrorMessage);

                var fullErrorMessage = string.Join("; ", errorMessages);

                Console.WriteLine("Book \"" + newBook.Title + "\" was not successfuly added");
                Console.WriteLine("Reason:\n" + fullErrorMessage);
            }
        }
  
        private static Review CreateReview(BookstoreEntities context, CustomReview review)
        {
            var newReveiw = new Review();

            if (review.AuthorName != null)
            {
                newReveiw.Author = CreateOrLoadAuthor(context, review.AuthorName);
            }

            newReveiw.Date = review.Date ?? DateTime.Now;
            newReveiw.Text = review.Text;

            return newReveiw;
        }

        public static IList<Book> FindBookByAuthorTitleAndIsbn(string author, string title, string isbn)
        {
            var context = new BookstoreEntities();
            var booksQuery =
                            from b in context.Books
                            select b;
            if (title != null)
            {
                booksQuery =
                            from b in context.Books
                            where b.Title == title
                            select b;
            }
            if (isbn != null)
            {
                booksQuery =
                            from b in context.Books
                            where b.ISBN == isbn
                            select b;
            }

            if (author != null)
            {
                booksQuery = booksQuery.Where(
                    b => b.Authors.Any(a => a.Name.ToLower() == author.ToLower()));
            }

            booksQuery = booksQuery.OrderBy(b => b.Title);

            return booksQuery.ToList();
        }
    }
}