import { FormEventHandler, useEffect, useState } from "react"
import { animalModel } from "../models/animalModel"
import AnimalCard from "./AnimalCard"
import { Button, Form } from "react-bootstrap"

interface QueryParams{
    enclosure: string | null, 
    species: string | null,
    classification: string | null, 
}

const AllAnimals: React.FC = () => {

const [queryParams, setQueryParams] = useState<QueryParams>({enclosure: null, species: null, classification: null})
const [enclosure, setEnclosure] = useState<string |null >(null);
const [species, setSpecies] = useState<string | null >(null);
const [classification, setClassification] = useState<string | null >(null);

const [currentPage, setCurrentPage] = useState(1);
const [itemsPerPage, setItemsPerPage] =useState(10);
const [totalPages, setTotalPages] = useState(0);

const [animalsInfo, setAnimalsInfo] = useState<animalModel[]>()
const [speciesInfo, setSpeciesInfo] = useState<string[]>([])
const [enclosuresInfo, setEnclosuresInfo] = useState<string[]>([]);
const [classificationInfo, setClassificationInfo] = useState<string[]>([]);
const [loading, setLoading] = useState(true);
const [error, setError] = useState(false);

const fetchData = () => {
    setLoading(true);

    const queryParamswithPage = {...queryParams, pageNum: currentPage, pageSize: itemsPerPage };
    const queryString = Object.entries(queryParamswithPage)
    .filter(([_, value]) => value !==null)
    .map(([key, value]) => `${key}=${value}`)
    .join("&")

    fetch(`http://localhost:5031/animals/filter?${queryString}`)
    .then(response => response.json())
    .then(data => {
        setAnimalsInfo(data.result)
        setTotalPages(data.totalPages)
    })
    .catch(() => setError(true))
    .finally(() => setLoading(false))
}

const fetchDefaults = () => {
    fetch("http://localhost:5031/animals/filter")
    .then(response => response.json())
    .then((data) => {
        setCurrentPage(data.currentPage);
        setItemsPerPage(data.itemsPerPage);
    })
    .catch(() => setError(true));
}
const fetchSpecies = () => {
    fetch("http://localhost:5031/animals/listall/species")
    .then(response => response.json())
    .then(data => setSpeciesInfo(data))
    .catch(() => setError(true))
    .finally(() => setLoading(false))
}

const fetchEnclosures = () => {
    fetch("http://localhost:5031/animals/listall/enclosures")
    .then(response => response.json())
    .then(data => setEnclosuresInfo(data))
    .catch(() => setError(true))
    .finally(() => setLoading(false))
}

const fetchClassifications = () => {
    fetch("http://localhost:5031/animals/listall/classifications")
    .then(response => response.json())
    .then(data => setClassificationInfo(data))
    .catch(() => setError(true))
    .finally(() => setLoading(false))
}

const handleSubmit: FormEventHandler = (event) => {
    event.preventDefault();
    setCurrentPage(1);
    setQueryParams({enclosure: enclosure, species: species, classification: classification});
    setEnclosure(null);
    setClassification(null);
    setSpecies(null);
    const form = event.target as HTMLFormElement
    form.reset()
}

const goToPreviousPage = () => {
    setCurrentPage(prevPage => prevPage -1);
}
const goToNextPage = () => {
    setCurrentPage(prevPage => prevPage +1)
}

useEffect(() => {
    fetchDefaults();
    fetchSpecies();
    fetchEnclosures();
    fetchClassifications();
}, [])

useEffect(() => {
    fetchData();
}, [queryParams, currentPage])
    

return (
    <div className="d-flex flex-column text-center">
        <div className="d-flex justify-content-center column-gap-5 mt-3">
            <Form onSubmit={handleSubmit} className="d-flex column-gap-3">
                <Form.Group>
                    <Form.Label>Enclosure:</Form.Label>
                    <Form.Select onChange ={(event) => setEnclosure(event.target.value)} > 
                        <option>Select an enclosure</option>
                        {enclosuresInfo.map((enclosure, index) => 
                            <option key={index} value={enclosure}>{enclosure}</option>
                        )}
                    </Form.Select>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Species:</Form.Label>
                    <Form.Select onChange ={(event) => setSpecies(event.target.value)} > 
                        <option>Select a species</option>                
                        {speciesInfo.map((species, index) =>
                            <option key={index} value={species}>{species}</option>
                        )}
                    </Form.Select>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Classification:</Form.Label>
                    <Form.Select onChange ={(event) => setClassification(event.target.value)} >
                        <option>Select a classification</option>
                        {classificationInfo.map((classification, index) =>
                        <option key={index} value={classification}>{classification}</option>
                        )}
                    </Form.Select>
                </Form.Group>
            <Button variant="primary" type="submit" disabled={loading} className="mt-3">
                Filter
            </Button>
        </Form>
    </div>
    {animalsInfo && (
    <>
        <div className="d-flex flex-wrap justify-content-center gap-4 my-4">
            {animalsInfo.map((animal) =>
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
        <div>  
            <Button
            disabled={currentPage === 1}
            className="mx-5"
            onClick={goToPreviousPage}
            >
                Previous
            </Button>
            <Button
            disabled={currentPage === totalPages}
            className="mx-5"
            onClick={goToNextPage}
            >
                Next
            </Button>
        </div> 
    </>
    )}
    {loading && <p>Loading...</p>}
    {error && <p>Unable to load data at this time</p>}
    </div>
    )
}

export default AllAnimals