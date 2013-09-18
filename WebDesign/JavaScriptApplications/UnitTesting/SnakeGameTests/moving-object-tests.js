/// <reference path="../SnakeGame" />
describe("MovingGameObject", function() {
    var position = {
        x: 150,
        y: 150
    };

    var size = 15,
        speed = 5,
        direction = 0,
        fcolor = "#00fff1",
        scolor = "#ff0011",
        movingGameObject;

    beforeEach(function() {
        movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, direction);
    });

    describe("init", function() {
        it("Should set correct values", function() {
            expect(movingGameObject.position).toEqual(position);
            expect(movingGameObject.size).toBe(size);
            expect(movingGameObject.fcolor).toBe(fcolor);
            expect(movingGameObject.scolor).toBe(scolor);
            expect(movingGameObject.speed).toBe(speed);
            expect(movingGameObject.direction).toBe(direction);
        });
    });

    describe("move", function() {
        it("when direction is 0, should decrease x", function() {
            movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 0);
            movingGameObject.move();
            expect(movingGameObject.position.x).toBe(position.x - speed);
            expect(movingGameObject.position.y).toBe(position.y);
        });

        it("when direction is 1, should decrease y", function() {
            movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 1);
            movingGameObject.move();
            expect(movingGameObject.position.x).toBe(position.x);
            expect(movingGameObject.position.y).toBe(position.y - speed);
        });

        it("when direction is 2, should increase x", function() {
            movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 2);
            movingGameObject.move();
            expect(movingGameObject.position.x).toBe(position.x + speed);
            expect(movingGameObject.position.y).toBe(position.y);
        });

        it("when direction is 3, should increase y", function() {
            movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed, 3);
            movingGameObject.move();
            expect(movingGameObject.position.x).toBe(position.x);
            expect(movingGameObject.position.y).toBe(position.y + speed);
        });
    });

        describe("changeDirection", function() {

        describe("when direction is 0", function() {
            beforeEach(function() {
                movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed 0);
            });

            it("new direction is 0, should set direction to 0", function() {
                movingGameObject.changeDirection(0);
                expect(movingGameObject.direction).toBe(0);
            });
            it("new direction is 1, should set direction to 1", function() {
                movingGameObject.changeDirection(1);
                expect(movingGameObject.direction).toBe(1);
            });
            it("new direction is 2, should set direction to 0", function() {
                movingGameObject.changeDirection(2);
                expect(movingGameObject.direction).toBe(0);
            });
            it("new direction is 3, should set direction to 3", function() {
                movingGameObject.changeDirection(3);
                expect(movingGameObject.direction).toBe(3);
            });
        });

        describe("when direction is 1", function() {
            beforeEach(function() {
                movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed 1);
            });

            it("new direction is 0, should set direction to 0", function() {
                movingGameObject.changeDirection(0);
                expect(movingGameObject.direction).toBe(0);
            });
            it("new direction is 1, should set direction to 1", function() {
                movingGameObject.changeDirection(1);
                expect(movingGameObject.direction).toBe(1);
            });
            it("new direction is 2, should set direction to 2", function() {
                movingGameObject.changeDirection(2);
                expect(movingGameObject.direction).toBe(2);
            });
            it("new direction is 3, should set direction to 1", function() {
                movingGameObject.changeDirection(3);
                expect(movingGameObject.direction).toBe(1);
            });
        });

        describe("when direction is 2", function() {
            beforeEach(function() {
                movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed 2);
            });

            it("new direction is 0, should set direction to 2", function() {
                movingGameObject.changeDirection(0);
                expect(movingGameObject.direction).toBe(2);
            });
            it("new direction is 1, should set direction to 1", function() {
                movingGameObject.changeDirection(1);
                expect(movingGameObject.direction).toBe(1);
            });
            it("new direction is 2, should set direction to 2", function() {
                movingGameObject.changeDirection(2);
                expect(movingGameObject.direction).toBe(2);
            });
            it("new direction is 3, should set direction to 3", function() {
                movingGameObject.changeDirection(3);
                expect(movingGameObject.direction).toBe(3);
            });
        });

        describe("when direction is 3", function() {
            beforeEach(function() {
                movingGameObject = new snakeGame.MovingGameObject(position, size, fcolor, scolor, speed 3);
            });

            it("new direction is 0, should set direction to 0", function() {
                movingGameObject.changeDirection(0);
                expect(movingGameObject.direction).toBe(0);
            });
            it("new direction is 1, should set direction to 3", function() {
                movingGameObject.changeDirection(1);
                expect(movingGameObject.direction).toBe(3);
            });
            it("new direction is 2, should set direction to 2", function() {
                movingGameObject.changeDirection(2);
                expect(movingGameObject.direction).toBe(2);
            });
            it("new direction is 3, should set direction to 3", function() {
                movingGameObject.changeDirection(3);
                expect(movingGameObject.direction).toBe(3);
            });
        });
});