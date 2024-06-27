import { DashboardOutlined } from '@ant-design/icons';

// icons
const icons = {
  DashboardOutlined
};

// ==============================|| MENU ITEMS - DASHBOARD ||============================== //

const dashboard = {
  id: 'group-dashboard',
  title: 'Navigation',
  type: 'group',
  children: [
    {
      id: 'dashboard',
      title: 'Dashboard',
      type: 'item',
      url: '/dashboard/default',
      icon: icons.DashboardOutlined,
      breadcrumbs: false,
      expandable: true,
      children: [
        {
          id: 'sample',
          title: 'Sample Page',
          type: 'item',
          url: '/dashboard/sample-page',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
        {
          id: 'CP',
          title: 'Capacity Provider',
          type: 'item',
          url: '/dashboard/CapacityProvider',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
        {
          id: 'Carrier',
          title: 'Carrier',
          type: 'item',
          url: '/dashboard/Carrier',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
        {
          id: 'Insurance',
          title: 'Insurance',
          type: 'item',
          url: '/dashboard/Insurance',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        }
      ]
    }
  ]
};

export default dashboard;
