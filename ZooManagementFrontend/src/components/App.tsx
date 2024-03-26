import "../main.scss"
import {BrowserRouter as Router, Route, Routes} from 'react-router-dom'
import { LinkContainer } from "react-router-bootstrap"
import { Button } from "react-bootstrap"
import Home from './Home'
import NavBar from './NavBar'
import AnimalDetail from './AnimalDetail'
import EnclosureDetail from './EnclosureDetail'
import AllAnimals from "./AllAnimals"

const App: React.FC = () => {

  return (
    <Router>
      <NavBar />
      <Routes>
        <Route path = '/' element = {<Home/>}/>
        <Route path = '/animals/animal/:animalId' element = {<AnimalDetail/>} />
        <Route path = '/enclosure/:enclosureId' element = {<EnclosureDetail/>} />
        <Route path = '/animals/all' element= {<AllAnimals />}/>
        <Route path = '*' element = {
          <div className="d-flex flex-column align-items-center">
            <h1 className="text-center">Oops, this page doesn't exist.<br/> Let's get you back to the home page:</h1>
            <LinkContainer to="/">
              <Button size="lg">Home</Button>
            </LinkContainer>
          </div>
        }/>
      </Routes>
    </Router>
  )
}

export default App