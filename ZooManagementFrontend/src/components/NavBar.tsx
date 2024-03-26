import {Container, Nav, Navbar, NavDropdown} from "react-bootstrap"

const NavBar: React.FC = () => {

    return (
        <Navbar expand="lg" className="bg-body-tertiary">
        <Container>
            <Navbar.Brand href="/">Zoo Management</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse id="basic-navbar-nav">
                <Nav className="me-auto">
                <Nav.Link href="/">Home</Nav.Link>
                <Nav.Link href="/animals/all">All Animals</Nav.Link>
                <NavDropdown title="Enclosures" id="basic-nav-dropdown">
                    <NavDropdown.Item href="/enclosure/-1">Giraffe</NavDropdown.Item>
                    <NavDropdown.Item href="/enclosure/-2">Aviary</NavDropdown.Item>
                    <NavDropdown.Item href="/enclosure/-3">Reptile</NavDropdown.Item>
                    <NavDropdown.Item href="/enclosure/-4">Reptile</NavDropdown.Item>
                    <NavDropdown.Item href="/enclosure/-5">Hippo</NavDropdown.Item>
                    <NavDropdown.Item href="/enclosure/-6">Lion</NavDropdown.Item>
                </NavDropdown>
                </Nav>
            </Navbar.Collapse>
        </Container>
        </Navbar>
        );
    }

export default NavBar
