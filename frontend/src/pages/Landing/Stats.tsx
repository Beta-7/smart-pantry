import React from 'react';
import { Container, Grid, Paper, Typography, Box } from '@mui/material';
import ExpirationTimeline, { OpenedProduct } from './ExpirationTimeline';

type StatsType = {
    quickRecipes: number;
    expiringRecipes: number;
    productsNearingExpiration: number;
    recentProducts: string[];
    longestOpened: string[];
    unopenedUnits: number;
    openedProducts: OpenedProduct[];
}

const stats: StatsType = {
  quickRecipes: 12,
  expiringRecipes: 5,
  productsNearingExpiration: 3,
  recentProducts: ['Tomatoes', 'Chicken Breast', 'Lettuce', 'Milk', 'Cheese'],
  longestOpened: ['Soy Sauce', 'Mustard', 'Jam'],
  unopenedUnits: 20,
  openedProducts: [
    { name: 'Tomatoes', startDate: '2024-10-01', endDate: '2024-10-20' },
    { name: 'Lettuce', startDate: '2024-10-11', endDate: '2024-10-25' },
    { name: 'Chicken Breast', startDate: '2024-10-12', endDate: '2024-10-20' },
    { name: 'Milk', startDate: '2024-10-15', endDate: '2024-10-22' },
  ],
};

const Stats = () => {
  return (
    <Container maxWidth="lg" sx={{ mt: 4 }}>
      <Typography variant="h3" gutterBottom>
        Kitchen Inventory Dashboard
      </Typography>
      
      <Grid container spacing={4}>
        {/* Quick Recipes */}
        <Grid item xs={12} sm={6} md={4}>
          <Paper sx={{ p: 3 }}>
            <Typography variant="h5">Quick Recipes Available</Typography>
            <Typography variant="h2" color="primary">{stats.quickRecipes}</Typography>
          </Paper>
        </Grid>

        {/* Expiring Recipes */}
        <Grid item xs={12} sm={6} md={4}>
          <Paper sx={{ p: 3 }}>
            <Typography variant="h5">Recipes Using Expiring Products</Typography>
            <Typography variant="h2" color="primary">{stats.expiringRecipes}</Typography>
          </Paper>
        </Grid>

        {/* Products Nearing Expiration */}
        <Grid item xs={12} sm={6} md={4}>
          <Paper sx={{ p: 3 }}>
            <Typography variant="h5">Products Nearing Expiration</Typography>
            <Typography variant="h2" color="error">{stats.productsNearingExpiration}</Typography>
          </Paper>
        </Grid>

        {/* Recently Used Products */}
        <Grid item xs={12} sm={6} md={4}>
          <Paper sx={{ p: 3 }}>
            <Typography variant="h5">Recently Used Products</Typography>
            <Box>
              {stats.recentProducts.map((product, index) => (
                <Typography key={index} variant="body1">
                  - {product}
                </Typography>
              ))}
            </Box>
          </Paper>
        </Grid>

        {/* Longest Opened Products */}
        <Grid item xs={12} sm={6} md={4}>
          <Paper sx={{ p: 3 }}>
            <Typography variant="h5">Longest Opened Products</Typography>
            <Box>
              {stats.longestOpened.map((product, index) => (
                <Typography key={index} variant="body1">
                  - {product}
                </Typography>
              ))}
            </Box>
          </Paper>
        </Grid>

        {/* Total Unopened Units */}
        <Grid item xs={12} sm={6} md={4}>
          <Paper sx={{ p: 3 }}>
            <Typography variant="h5">Total Unopened Units</Typography>
            <Typography variant="h2" color="primary">{stats.unopenedUnits}</Typography>
          </Paper>
        </Grid>
      </Grid>
      <ExpirationTimeline openedProducts={stats.openedProducts}/>

    </Container>
  );
};

export default Stats;
