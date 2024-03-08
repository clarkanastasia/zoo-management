import {useState, useEffect} from 'react'
import {animalModel} from '../models/animalModel'
import {useParams} from 'react-router-dom'

const AnimalDetail: React.FC = () => {
    const { animalId } = useParams();
    const URL = `http://localhost:5031/animals/animal/${animalId}`;
    const [myData, setData] = useState<animalModel|null>(null);

    useEffect(() => {
        fetch(URL)
        .then(response => response.json())
        .then((data) => {
            setData(data);
        })
        .catch(error => {
            console.log(error);
        })
            
    }, []);

    if(myData == null){
        return <h1>Loading data</h1>
    }

    return (
        <div>
            <ul>
                <li>Name: {myData.name}</li>
                <li>Species: {myData.species}</li>
                <li>Classification: {myData.classification}</li>
                <li>Sex: {myData.sex}</li>
                <li>Enclosure: {myData.enclosure}</li>
                {myData.dateOfBirth && (
                <li> Date of Birth: {myData.dateOfBirth}</li>)}
                <li>Date of Acquisition: {myData.dateOfAcquisition}</li>
            </ul>
        </div>
    )
    }

export default AnimalDetail
