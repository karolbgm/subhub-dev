import { Outlet, useLocation } from "react-router-dom";
import "./App.css";
import SubhubTable from "./components/subscriptions/SubhubTable";
import { Container } from "react-bootstrap";
import { useEffect } from "react";
import { setupErrorHandlingInterceptor } from "./interceptors/axiosInt";

function App() {
  const location = useLocation();

  useEffect(() => {
    setupErrorHandlingInterceptor();
  }, []);
  return (
    <>
      {location.pathname === "/" ? (
        <SubhubTable />
      ) : (
        <Container>
          <Outlet />
        </Container>
      )}
    </>
  );
}

export default App;
