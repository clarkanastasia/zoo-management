import {animalModel} from './animalModel'

export interface enclosureModel {
    id: number, 
    type: string,
    population: number,
    capacity: number,
    animals: animalModel[]
}