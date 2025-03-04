import React, { useEffect, useState } from 'react';
import MaterialTable, { Column } from '@material-table/core';
import { StockedProductApi } from '../../dataAgent';
import { IStockedProduct } from '../../model/StockedProduct';


const OpenProductsTable: React.FC = () => {
  const [data, setData] = useState<IStockedProduct[]>([]);

  useEffect(()=>{
    const fetchData = async () => {
      const resp = await StockedProductApi.all();
      setData(resp);
    };
    fetchData();
  },[])

  const columns: Column<IStockedProduct>[] = [
    { title: 'Name', field: 'name' },
    { title: 'Barcode', field: 'barcode'},
    { title: 'Expiration Date', field: 'expirationDate' },
    { title: 'packagingWeight', field: 'packagingWeight', type: 'numeric' },
    { title: 'Weight', field: 'weight', type: 'numeric' },
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
