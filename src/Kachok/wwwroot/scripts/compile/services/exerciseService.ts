/// <reference path="../_all.ts" />


module KachokApp {
    export interface IExerciseService {
        loadAllExercises(): ng.IPromise<Exercise[]>;
        loadAllMuscleGroups(): ng.IPromise<MuscleGroup[]>;
        selectedExercise: Exercise;
    }

    export class ExerciseService implements IExerciseService {
        static $inject = ['$q', '$http'];


        constructor(private $q: ng.IQService, private $http: ng.IHttpService) {
            var self = this;
        }

        selectedExercise: Exercise = null;
        muscleGroups: MuscleGroup[] = [];
        exercises: Exercise[] = [];

        loadAllExercises2(): ng.IPromise<Exercise[]> {
            return this.$q.when(this.exercises);
        }

        loadAllMuscleGroups(): ng.IPromise<MuscleGroup[]> {
            return this.$http.get("/api/Admin/MuscleGroups")
                .then((response) => {
                    if (response) {
                        angular.copy(response.data, this.muscleGroups);
                    }
                    return this.muscleGroups;
                });
        };

        loadAllExercises(): ng.IPromise<Exercise[]> {
            return this.$http.get("/api/Exercises")
                .then((response) => {
                    //if (response) {
                    //    angular.copy(response.data, this.exercises);
                    //}

                    return this.exercisesTmp;
                });
        };

        private exercisesTmp: Exercise[] = [
            {
                id: 1,
                name: "Exercise 1",
                description: "Description 1",
                targetMuscleGroupName: "Neck",
                exerciseTags: [
                    { id:1, tagName:"Tag 1" },
                    { id:2, tagName:"Tag 2" },
                    { id:3, tagName:"Tag 3" }
                    ]
            },
            {
                id: 2,
                name: "Exercise 2",
                description: "Description 2",
                targetMuscleGroupName: "Neck",
                exerciseTags: []
            }
        ];
    }
}