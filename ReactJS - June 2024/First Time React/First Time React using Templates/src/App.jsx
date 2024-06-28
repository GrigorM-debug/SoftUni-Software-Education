import About from './components/About';
import Contact from './components/Contact';
import Footer from './components/Footer';
import Menu from './components/Menu';
import Navbar from './components/Navbar';
import Reviews from './components/Reviews';
import Team from './components/Team/Team';
import Welcome from './components/Welcome';

function App() {

  return (
    <>
      <Navbar/>
      <Welcome/>
      <About/>
      <Team/>
      <Menu/>
      <Reviews/>
      <Contact/>
      <Footer/>
    </>
  )
}

export default App;
