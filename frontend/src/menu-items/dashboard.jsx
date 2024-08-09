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
      url: '/',
      icon: icons.DashboardOutlined,
      breadcrumbs: false,
      expandable: true,
      children: [
        {
          id: '1',
          title: 'Carrier',
          type: 'item',
          url: '/carrier',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
        {
          id: '2',
          title: 'CompanyId',
          type: 'item',
          url: '/companyId',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
        {
          id: '3',
          title: 'Claim',
          type: 'item',
          url: '/claims',
          icon: icons.DashboardOutlined,
          breadcrumbs: false
        },
      ]
    }
  ]
};

export default dashboard;
