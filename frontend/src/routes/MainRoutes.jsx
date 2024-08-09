import { lazy } from 'react';

// project import
import Loadable from 'components/Loadable';
import Dashboard from 'layout/Dashboard';
import Carrier from 'pages/Carrier/Presentation/Form/Carrier';
import { User } from 'pages/CompanyId/Container/Grid';
import { element } from 'prop-types';
import ClaimsList from 'pages/Claim/Presentation/list';

const DashboardDefault = Loadable(lazy(() => import('pages/dashboard/container/index')));
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
      path: '/',
      children: [
        {
          path: '/',
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
        {
          path:'Claims',
          element: <ClaimsList/>
        },
      ]
    },
  ]
};

export default MainRoutes;
