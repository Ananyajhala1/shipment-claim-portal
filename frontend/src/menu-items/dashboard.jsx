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
          id: '1',
          title: 'Carrier',
          type: 'item',
          url: '/dashboard/carrier',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
        {
          id: '2',
          title: 'CompanyId',
          type: 'item',
          url: '/dashboard/companyId',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
      ]
    }
  ]
};

export default dashboard;
