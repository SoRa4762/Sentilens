import { Outlet } from "react-router-dom";

function App() {
  return (
    <>
      <header>
        <nav>
          <a href="/">Home</a>
          <a href="/about">About</a>
          <a href="/dashboard">Dashboard</a>
          <a href="/login">Login</a>
        </nav>
      </header>

      <main>
        <Outlet />
      </main>

      <footer>
        <p className="read-the-docs">
          Click on the Vite and React logos to learn more
        </p>
      </footer>
    </>
  );
}

export default App;
