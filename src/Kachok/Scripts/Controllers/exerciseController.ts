/// <reference path="../_all.ts" />


module KachokApp {
    export class ExerciseController{

        static $inject = ['exerciseService'];

        constructor(private exerciseService: IExerciseService) {
            var self = this;

            this.exerciseService
                .loadAllExercises()
                .then((exercises: Exercise[]) => {
                    self.exercises = exercises;
                    console.log(self.exercises);
                });
        }

        Message: string = "Hello from our controller";
        exercises: Exercise[] = [];

    }
}