import { Button, Card, CardText } from 'react-bootstrap'
import { LinkContainer } from 'react-router-bootstrap'

interface AnimalCardProps {
    id: number,
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
export default AnimalCard