import '../styles/App.css'
import {BrowserRouter as Router, Route, Routes, Link} from 'react-router-dom'
import Home from './Home'
import NavBar from './NavBar'
import AnimalDetail from './AnimalDetail'
import EnclosureDetail from './EnclosureDetail'


const App: React.FC = () => {

  return (
    <Router>
      <NavBar />
      <Routes>
        <Route path = '/' element = {<Home/>}/>
        <Route path = '/animals/animal/:animalId' element = {<AnimalDetail/>} />
        <Route path = '/enclosure/:enclosureId' element = {<EnclosureDetail/>} />

        <Route path = '*' element = {
          <div>
            <h1>Oops, this page doesn't exist. Let's get you back to the home page:</h1>
            <Link to = '/'>Home</Link>
          </div>
        }/>
      </Routes>
    </Router>
  )
}

export default App
