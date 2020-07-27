import React from "react";
import "./App.css";
import { UserProfileProvider } from "./UserProfileProvider/UserProfileProvider";
import UserProfileList from "./Components/UserProfileList";

function App() {
  return (
    <div className="App">
      <UserProfileProvider>
        <UserProfileList />
      </UserProfileProvider>
    </div>
  );
}

export default App;