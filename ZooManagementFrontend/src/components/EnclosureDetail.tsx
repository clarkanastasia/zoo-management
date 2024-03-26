import { useState, useEffect } from 'react'
import { animalModel } from '../models/animalModel'
import { enclosureModel } from '../models/enclosureModel'
import { useParams } from 'react-router-dom'
import { Button, Card, CardText } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

interface AnimalCardProps {
    id: number
    name: string, 
    species: string,
    classification: string;
    sex: string;
    dateOfAcquisition: string;
}

const AnimalCard: React.FC<AnimalCardProps> = ({id, name, species, sex, dateOfAcquisition}) => {
    return(
        <LinkContainer to={`/animals/animal/${id}`}>
            <Card style={{width:"13rem"}}>
                <Card.Body>
                    <Card.Title>{name}</Card.Title> 
                    <Card.Subtitle>{species} ({sex})</Card.Subtitle>
                    <CardText>Acquired: {dateOfAcquisition}</CardText>
                    <LinkContainer to={`/animals/animal/${id}`}>
                        <Button>See More</Button>
                    </LinkContainer>
                </Card.Body>
            </Card>
        </LinkContainer>
    )
}

const EnclosureDetail: React.FC = () => {
    const { enclosureId } = useParams();
    const URL = `http://localhost:5031/enclosure/${enclosureId}`;
    const [enclosureInfo, setEnclosureInfo] = useState<enclosureModel>();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);

    useEffect(() => {
        fetch(URL)
        .then(response => response.json())
        .then((data) => {
            setEnclosureInfo(data);
        })
        .catch(() => setError(true))
        .finally(() => setLoading(false))       
    }, []);

    return(
        <div className="d-flex flex-column text-center">
            {enclosureInfo && (
                <div className="mt-5">
                    <h3>Enclosure: {enclosureInfo.type}</h3>
                    <h3>Population: {enclosureInfo.population} animals</h3>
                    <h3>Capacity: {enclosureInfo.capacity} animals</h3>
                    <div className="d-flex flex-wrap justify-content-center gap-4 my-4">
                        {enclosureInfo.animals.map((animal : animalModel) =>
                            <AnimalCard 
                                key={animal.id}
                                id={animal.id}
                                name={animal.name}
                                species={animal.species}
                                classification={animal.classification}
                                sex={animal.sex}
                                dateOfAcquisition={animal.dateOfAcquisition}
                            />                
                        )}
                    </div>
                </div>
            )}
            {loading && <p>Loading...</p>}
            {error && <p>Unable to load data at this time</p>}
        </div>
    )
}

export default EnclosureDetail