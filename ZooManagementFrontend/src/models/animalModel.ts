export interface animalModel {
    id : number,
    name: string,
    species: string;
    classification: string;
    sex: string;
    enclosureId: number,
    enclosure: string;
    dateOfBirth?: string;
    dateOfAcquisition: string;
}