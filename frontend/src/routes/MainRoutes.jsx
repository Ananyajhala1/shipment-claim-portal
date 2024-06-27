import { lazy } from 'react';

// project import
import Loadable from 'components/Loadable';
import Dashboard from 'layout/Dashboard';

const Color = Loadable(lazy(() => import('pages/component-overview/color')));
const Typography = Loadable(lazy(() => import('pages/component-overview/typography')));
const Shadow = Loadable(lazy(() => import('pages/component-overview/shadows')));
const DashboardDefault = Loadable(lazy(() => import('pages/dashboard/index')));
const SamplePage = Loadable(lazy(() => import('pages/dashboard/sample-page')));
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
      path: 'color',
      element: <Color />
    },
    {
      path: 'dashboard',
      children: [
        {
          path: 'default',
          element: <DashboardDefault />
        },
        {
          path: 'sample-page',
          element: <SamplePage />
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
    
    {
      path: 'shadow',
      element: <Shadow />
    },
    {
      path: 'typography',
      element: <Typography />
    }
  ]
};

export default MainRoutes;
