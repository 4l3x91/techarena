import "bootstrap";
import React from "react";
import ReactDOM from "react-dom/client";
import { QueryClient, QueryClientProvider } from "react-query";
import { ReactQueryDevtools } from "react-query/devtools";
import { BrowserRouter } from "react-router-dom";
import App from "./App.tsx";
import UserProvider from "./contexts/UserContext.tsx";

const queryClient = new QueryClient();
ReactDOM.createRoot(document.getElementById("root") as HTMLElement).render(
  <React.StrictMode>
    <QueryClientProvider client={queryClient}>
      <ReactQueryDevtools position="top-right" />
      <BrowserRouter>
      <UserProvider>
        <App />
      </UserProvider>
      </BrowserRouter>
    </QueryClientProvider>
  </React.StrictMode>
);
