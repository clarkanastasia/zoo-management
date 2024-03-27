import {useState, useEffect} from 'react'
import {animalModel} from '../models/animalModel'
import {useParams} from 'react-router-dom'
import { Button, Card, CardBody, ListGroup, ListGroupItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

const AnimalDetail: React.FC = () => {
    const { animalId } = useParams();
    const URL = `http://localhost:5031/animals/animal/${animalId}`;
    const [animalInfo, setAnimalInfo] = useState<animalModel>();
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(false);

    useEffect(() => {
        fetch(URL)
        .then(response => response.json())
        .then((data) => {
            setAnimalInfo(data);
        })
        .catch(() => setError(true))
        .finally(() => setLoading(false))      
    }, []);

    return (
        <div className="d-flex flex-column align-items-center text-center" style={{marginTop:"5rem"}}>
            {animalInfo && (
                <Card style={{ width: '20rem' }}>
                    <CardBody>
                    <Card.Title>{animalInfo.name}</Card.Title>
                        <ListGroup>
                            <ListGroupItem>Species: {animalInfo.species}</ListGroupItem>
                            <ListGroupItem>Classification: {animalInfo.classification}</ListGroupItem>
                            <ListGroupItem>Sex: {animalInfo.sex}</ListGroupItem>
                            {animalInfo.dateOfBirth && (
                                <ListGroupItem>Date of Birth: {animalInfo.dateOfBirth}</ListGroupItem>
                            )}
                            <ListGroupItem>Date of Acquisition: {animalInfo.dateOfAcquisition}</ListGroupItem>
                        </ListGroup>
                        <LinkContainer to={`/enclosure/${animalInfo.enclosureId}`}>
                            <Button className="mt-3">Back to Enclosure</Button>
                        </LinkContainer>
                        </CardBody>

                </Card>
            )}
            {loading && <p>Loading...</p>}
            {error && <p>Unable to load data at this time</p>}
        </div>
    )
    }

export default AnimalDetail
