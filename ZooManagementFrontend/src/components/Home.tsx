import "../main.scss"
import { Button } from "react-bootstrap"
import { LinkContainer } from "react-router-bootstrap"

const Home: React.FC = () => {
    return (
        <div className="homePage">
            <h1>Zoo Management System</h1>
            <h2>Which enclosure would you like to see?</h2>
            <LinkContainer to="/enclosure/-1">
                <Button size="lg">Giraffe</Button>
            </LinkContainer>
            <LinkContainer to="/enclosure/-2">
                <Button size="lg">Aviary</Button>
            </LinkContainer>
            <LinkContainer to="/enclosure/-3">
                <Button size="lg">Reptile</Button>
            </LinkContainer>
            <LinkContainer to="/enclosure/-4">
                <Button size="lg">Hippo</Button>
            </LinkContainer>
            <LinkContainer to="/enclosure/-5">
                <Button size="lg">Lion</Button>
            </LinkContainer>
        </div> 
    )}

export default Home