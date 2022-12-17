import logo from './logo.svg';
import './App.css';
import { store } from "./actions/store";
import {Provider} from "react-redux";

function App() {
  return (
   <Provider store={store}>
    <decandidates/>
   </Provider>
  );
}

export default App;
