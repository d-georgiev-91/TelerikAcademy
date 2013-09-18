namespace StringCountWithinStringServiceLibrary
{
    using System;
    using System.ServiceModel;

    [ServiceContract]
    public interface IServiceStringCountWithinString
    {
        [OperationContract]
        int GetStringCountWithinString(string innerString, string outerString);
    }
}