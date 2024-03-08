import {useState, useEffect} from 'react'
import {animalModel} from '../models/animalModel'
import {enclosureModel} from '../models/enclosureModel'
import {useParams} from 'react-router-dom'

const EnclosureDetail: React.FC = () => {
    const { enclosureId } = useParams();
    const URL = `http://localhost:5031/enclosure/${enclosureId}`;
    const [myData, setData] = useState<enclosureModel|null>(null);

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
                <li>Type: {myData.type}</li>
                <li>Population: {myData.population}</li>
                <li>Capacity: {myData.capacity}</li>
                <li>Animals: </li>
                {myData.animals.map((animal : animalModel) =>
                <ol key= {animal.id}> 
                    <li>Name: {animal.name}</li>
                    <li>Species: {animal.species}</li>
                    <li>Classification: {animal.classification}</li>
                    <li>Sex: {animal.sex}</li>
                    {animal.dateOfBirth && (
                    <li> Date of Birth: {animal.dateOfBirth}</li>)}
                    <li>Date of Acquisition: {animal.dateOfAcquisition}</li>
                </ol>
                )}
                
            </ul>
        </div>
    )
    }

export default EnclosureDetail
