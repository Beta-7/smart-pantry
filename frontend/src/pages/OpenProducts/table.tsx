import React from 'react';
import MaterialTable, { Column } from '@material-table/core';

interface Data {
    name: string;
    remainingWeight: number;
    expirationDate: string; // or Date if using Date objects
    openDate: string;       // or Date if using Date objects
    weight: number;
    daysRemaining: number;
  }

const OpenProductsTable: React.FC = () => {
  const data: Data[] = [
    {
      name: 'Apples',
      remainingWeight: 5.5,
      expirationDate: '2025-02-15',
      openDate: '2025-01-10',
      weight: 10,
      daysRemaining: 25,
    },
    {
      name: 'Bananas',
      remainingWeight: 3.2,
      expirationDate: '2025-01-25',
      openDate: '2025-01-05',
      weight: 6,
      daysRemaining: 5,
    },
    {
      name: 'Oranges',
      remainingWeight: 2.8,
      expirationDate: '2025-03-01',
      openDate: '2025-01-15',
      weight: 8,
      daysRemaining: 40,
    },
  ];

  const columns: Column<Data>[] = [
    { title: 'Name', field: 'name' },
    { title: 'Remaining Weight', field: 'remainingWeight', type: 'numeric' },
    { title: 'Expiration Date', field: 'expirationDate' },
    { title: 'Open Date', field: 'openDate' },
    { title: 'Weight', field: 'weight', type: 'numeric' },
    { title: 'Days Remaining', field: 'daysRemaining', type: 'numeric' },
  ];

  return (
    <MaterialTable
      title="Open products table"
      data={data}
      columns={columns}
      options={{
        search: true,
        sorting: true,
        paging: true,
      }}
    />
  );
};

export default OpenProductsTable;
