import { lazy } from 'react';

// project import
import Loadable from 'components/Loadable';
import Dashboard from 'layout/Dashboard';

const DashboardDefault = Loadable(lazy(() => import('pages/dashboard/index')));
const CapacityProvider = Loadable(lazy(() => import('pages/dashboard/CapacityProvider')));
const Carrier = Loadable(lazy(() => import('pages/dashboard/Carrier')));
const Insurance = Loadable(lazy(() => import('pages/dashboard/Insurance')));

// ==============================|| MAIN ROUTING ||============================== //

const MainRoutes = {
  path: '/',
  element: <Dashboard />,
  children: [
    {
      path: '/',
      element: <DashboardDefault />
    },
    {
      path: 'dashboard',
      children: [
        {
          path: 'default',
          element: <DashboardDefault />
        },
        {
          path:'CapacityProvider',
          element: <CapacityProvider />
        },
        {
          path:'Carrier',
          element: <Carrier />
        },
        {
          path:'Insurance',
          element: <Insurance />
        }
      ]
    },
  ]
};

export default MainRoutes;
