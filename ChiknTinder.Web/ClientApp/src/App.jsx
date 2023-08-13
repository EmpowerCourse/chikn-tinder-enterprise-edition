import { Route, Routes } from "react-router-dom";
import Login from "./pages/Login";
import useStore from "./hooks/useStore";

function App() {
  const currentUser = useStore((x) => x.currentUser);

  return (
    <>
      {currentUser ? (
        <Routes>
          <Route path="/" element={<>henlo</>} />
          <Route path="*" element={<>Not found</>} />
        </Routes>
      ) : (
        <Routes>
          <Route path="*" element={<Login />} />
        </Routes>
      )}
    </>
  );
}

export default App;
