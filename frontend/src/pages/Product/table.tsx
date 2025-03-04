import React, { useEffect, useState } from 'react';
import MaterialTable, { Column } from '@material-table/core';
import { ProductApi } from '../../dataAgent';
import { IProduct } from '../../model/Product';


const OpenProductsTable: React.FC = () => {
  const [data, setData] = useState<IProduct[]>([]);

  useEffect(()=>{
    const fetchData = async () => {
      const resp = await ProductApi.all();
      setData(resp);
    };
    fetchData();
  },[])

  const columns: Column<IProduct>[] = [
    { title: 'Name', field: 'name' },
    { title: 'barcode', field: 'barcode' },
    { title: 'Expiration Days after open', field: 'expirationDaysAfterOpen', type: 'numeric' },
    { title: 'Packaging weight', field: 'packagingWeight', type: 'numeric' },
    { title: 'Weight', field: 'weight', type: 'numeric' },
  ];

  return (
    <MaterialTable
      title="Products table"
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
