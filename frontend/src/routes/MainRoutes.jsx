import { lazy } from 'react';

// project import
import Loadable from 'components/Loadable';
import Dashboard from 'layout/Dashboard';
import Carrier from 'pages/Carrier/Presentation/Form/Carrier';
import { User } from 'pages/CompanyId/Container/Grid';

const DashboardDefault = Loadable(lazy(() => import('pages/dashboard/index')));
// const Carrier = Loadable(lazy(() => import('pages/Carrier/Presentation/Form/Carrier')));

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
          path:'Carrier',
          element: <Carrier/>
        },
        {
          path:'companyId',
          element: <User/>
        },
        
      ]
    },
  ]
};

export default MainRoutes;
