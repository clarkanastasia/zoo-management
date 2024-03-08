
const Home: React.FC = () => {

    return (
        <div>
        <h1>Welcome to Zoo Management</h1>
        <p>Which enclosure would you like to visit</p>
        <ul>
            <li><a href="/enclosure/-1">Giraffe</a></li>
            <li><a href="/enclosure/-2">Aviary</a></li>
            <li><a href="/enclosure/-3">Reptile</a></li>
            <li><a href="/enclosure/-4">Hippo</a></li>
            <li><a href="/enclosure/-5">Lion</a></li>
        </ul>
        </div>
    )
    }

export default Home
