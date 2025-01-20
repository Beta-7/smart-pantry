import React from 'react';
import { Paper, Typography, Box } from '@mui/material';
import { XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, BarChart, Bar, Cell } from 'recharts';
import { addMilliseconds, format } from 'date-fns';

export type OpenedProduct = {
    name: string,
    startDate: string,
    endDate: string
}

type Props = {
    openedProducts: OpenedProduct[]
}

const getBarColor = (daysLeft: number) => {
  daysLeft = Math.ceil(daysLeft/1000/60/60/24)
  if (daysLeft <= 0) return '#FF0000'; // Fully expired - Red
  if (daysLeft <= 3) return '#FF4500'; // Very close to expiration - Orange Red
  if (daysLeft <= 7) return '#FF8C00'; // Close to expiration - Dark Orange
  if (daysLeft <= 14) return '#FFD700'; // Expiring soon - Gold
  return '#32CD32'; // More time left - LimeGreen
};

const transformDataForGantt = (products: OpenedProduct[]) => {
  return products.map(product => ({
    name: product.name,
    start: Date.now(),
    end: new Date(product.endDate).getTime(),
    duration: (+new Date(product.endDate) - +new Date(Date.now())),
    color: getBarColor((+new Date(product.endDate) - +new Date(Date.now())))
  }));
};

const ExpirationTimeline = ({ openedProducts }: Props) => {
  const chartData = transformDataForGantt(openedProducts);
  console.log(chartData);
  // eslint-disable-next-line no-debugger
  debugger;
  return (
    <Paper sx={{ p: 3 }}>
      <Typography variant="h5" gutterBottom>
        Opened Products Expiration Gantt Chart
      </Typography>
      <Box sx={{ height: 300 }}>
        <ResponsiveContainer width="100%" height="100%">
          <BarChart
            data={chartData}
            layout="vertical"
            margin={{ top: 20, right: 30, left: 50, bottom: 5 }}
          >
            <CartesianGrid strokeDasharray="3 3" />
            {/* Use XAxis with type number for dates and format them */}
            <XAxis
              type="number"
              domain={[0, 'dataMax']}
              tickFormatter={(timestamp) => {
                const today = Date.now(); // Get today's timestamp
                const newDate = addMilliseconds(today, timestamp); // Add the timestamp as duration
                return format(newDate, 'MMM dd, yyyy'); // Format the resulting date
              }}
              />
            <YAxis type="category" dataKey="name" />
            <Tooltip
              labelFormatter={(name) => `Product: ${name}`}
              formatter={(timestamp) => {
                const today = Date.now(); // Get today's timestamp
                const newDate = addMilliseconds(today, +timestamp); // Add the timestamp as duration
                return `Expires in ${Math.ceil(+timestamp/1000/60/60/24)} days at ${format(newDate, 'MMM dd, yyyy')}`
              }}
            />
            <Bar
              dataKey="duration"
              name="Expiration"
              // eslint-disable-next-line @typescript-eslint/no-explicit-any
              isAnimationActive={false}
              barSize={20}
              background={{ fill: '#eee' }}
            >
              {chartData.map((entry, index) => (
                <Cell key={`cell-${index}`} fill={entry.color} /> // Use the color from data
              ))}
              </Bar>
          </BarChart>
        </ResponsiveContainer>
      </Box>
    </Paper>
  );
};

export default ExpirationTimeline;
