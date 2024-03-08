import { RouteObject, createBrowserRouter } from "react-router-dom";
import App from "../App";
import SubForm from "../components/subscriptions/SubForm";
import SubhubTable from "../components/subscriptions/SubhubTable";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children: [
            {path: 'createSubscription', element: <SubForm key='create' />},
            {path: 'editSubscription/:id', element: <SubForm key='edit' />},
            {path: '*', element: <SubhubTable />}
        ]
    }
]

export const router = createBrowserRouter(routes)