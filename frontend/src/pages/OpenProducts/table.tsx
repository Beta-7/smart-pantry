import React, { useEffect, useState } from 'react';
import MaterialTable, { Column } from '@material-table/core';
import { IOpenProduct } from '../../model/OpenProduct';
import { OpenProductApi } from '../../dataAgent';


const OpenProductsTable: React.FC = () => {
  const [data, setData] = useState<IOpenProduct[]>([]);

  useEffect(()=>{
    const fetchData = async () => {
      const resp = await OpenProductApi.all();
      setData(resp);
    };
    fetchData();
  },[])

  const columns: Column<IOpenProduct>[] = [
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
