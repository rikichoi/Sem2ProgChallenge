import * as React from 'react';
import AppBar from '@mui/material/AppBar';
import { Button, Card, CardContent, Typography, TextField } from '@mui/material'
import Toolbar from '@mui/material/Toolbar';
import Container from '@mui/material/Container';
import MenuItem from '@mui/material/MenuItem';
import Center from './Center';
import { useState, useEffect } from 'react';
import axios from 'axios';
import InputLabel from '@mui/material/InputLabel';
import FormControl from '@mui/material/FormControl';
import Select from '@mui/material/Select';
import Grid from '@mui/material/Grid';


const Home = () => {




  // useEffect(() => {
  //   axios.get(`https://localhost:7050/api/`)
  //     .then(resp => {
  //       setProcedures(resp.data);
  //     }
  //     )
  // }, [userID]);

  // useEffect(() => {
  //   axios.get(`https://practicevetapi.azurewebsites.net/api/TblTreatments/Treatments/${userID}`)
  //     .then(resp => {
  //       setTreatments(resp.data.ownerTreatmentsObject);
  //       setPetNames(resp.data.ownerTreatmentsObject.petname);
  //     }
  //     )
  // }, [userID, updated]);

  const [updated, setUpdated] = useState(false);

  useEffect(() => {
    axios.get(`https://localhost:7050/api/Orders`)
      .then(resp => {
        setOrders(resp.data);
        // console.log(resp);
      }
      )
  }, [updated, setUpdated, []]);

  useEffect(() => {
    axios.get(`https://localhost:7050/api/Customers`)
      .then(resp => {
        setCustomers(resp.data);
        // console.log(resp);
      }
      )
  }, []);

  useEffect(() => {
    axios.get(`https://localhost:7050/api/Products`)
      .then(resp => {
        setProducts(resp.data);
        // console.log(resp);
      }
      )
  }, []);

  useEffect(() => {
    axios.get(`https://localhost:7050/api/Shippings`)
      .then(resp => {
        setShippings(resp.data);
        // console.log(resp);
      }
      )
  }, []);

  const [toggle, setToggle] = useState(false);

  const [orders, setOrders] = useState([]);

  const [customers, setCustomers] = useState([]);

  const [products, setProducts] = useState([]);

  const [shippings, setShippings] = useState([]);

  const [orderDate, setOrderDate] = useState("");

  const [prodID, setProdID] = React.useState('');

  const [custID, setCustID] = useState('');

  const [shipMode, setShipMode] = useState('');

  const [quantity, setQuantity] = useState('');

  const [shipDate, setShipDate] = useState('');

  const [editOrderDate, setEditOrderDate] = useState("");

  const [editProdID, setEditProdID] = React.useState('');

  const [editCustID, setEditCustID] = useState('');

  const [editShipDate, setEditShipDate] = useState("");

  const [editShipMode, setEditShipMode] = React.useState('');

  const [editQuantity, setEditQuantity] = useState('');

  const handleCustIdChange = (event) => {
    setCustID(event.target.value);
  };

  const handleProductIdChange = (event) => {
    setProdID(event.target.value);
  };

  const handleShippingModeChange = (event) => {
    setShipMode(event.target.value);
  };

  const handleEditShipModeChange = (event) => {
    setEditShipMode(event.target.value);
  };

  const clearInput = () => {
    setOrderDate("");
    setProdID("");
    setCustID("");
    setShipMode("");
    setQuantity("");
    setShipDate("");
    setEditOrderDate("");
    setEditProdID("");
    setEditCustID("");
    setEditShipDate("");
    setEditShipMode("");
    setEditQuantity("");
  }


  return (
    <>
      <AppBar position="static">
        <Container maxWidth="xl">
          <Toolbar disableGutters>
            <Typography
              variant="h6"
              noWrap
              component="a"
              href="/"
              sx={{
                mr: 2,
                display: { xs: 'flex', md: 'flex' },
                fontFamily: 'monospace',
                fontWeight: 700,
                letterSpacing: '.3rem',
                color: 'cyan',
                textDecoration: 'none',
              }}
            >
              PROGRAMMING CHALLENGE
            </Typography>
          </Toolbar>
        </Container>
      </AppBar>



      <Center>
        <Grid container spacing={2}>
          <Grid item xs={6} m={6} l={6}>
            <Card sx={{ width: 500, m: 2 }}>
              <CardContent sx={{ textAlign: 'center' }}>
                <Typography variant="h5" sx={{ my: 3 }}>
                  Orders
                </Typography>

                <Button onClick={() => (setToggle(!toggle), setOrderDate(""), setProdID(""), setShipMode(""), setCustID(""), setQuantity(""), setShipDate(""))} variant="contained" sx={{ my: 3 }}>Create Order</Button>
                {toggle && (
                  <div>
                    <FormControl sx={{ minWidth: 200, m: 1 }}>
                      <InputLabel id="demo-simple-select-label">Customer ID</InputLabel>
                      <Select
                        labelId="simple-select-label-pet"
                        id="simple-select-pet"
                        value={custID}
                        label="CustomerID"
                        onChange={handleCustIdChange}
                      >
                        {customers.map(customers => {
                          return (
                            <MenuItem value={customers.custId}>{customers.custId}</MenuItem>
                          )
                        })}
                      </Select>
                    </FormControl>
                    <FormControl sx={{ minWidth: 200, m: 1 }}>
                      <InputLabel id="demo-simple-select-label">Product ID</InputLabel>
                      <Select
                        labelId="simple-select-label-procedureid"
                        id="simple-select-procedureid"
                        value={prodID}
                        label="ProductID"
                        onChange={handleProductIdChange}
                      >
                        {products.map(products => {
                          return (
                            <MenuItem value={products.prodId}>{products.prodId}</MenuItem>
                          )
                        })}
                      </Select>
                    </FormControl>
                    <FormControl sx={{ minWidth: 200, m: 1 }}>
                      <InputLabel id="demo-simple-select-label">Shipping Mode</InputLabel>
                      <Select
                        labelId="simple-select-label-procedureid"
                        id="simple-select-procedureid"
                        value={shipMode}
                        label="ShippingMode"
                        onChange={handleShippingModeChange}
                      >
                        {shippings.map(shippings => {
                          return (
                            <MenuItem value={shippings.shipMode}>{shippings.shipMode}</MenuItem>
                          )
                        })}
                      </Select>
                    </FormControl>

                    <TextField
                      sx={{ m: 1 }}
                      label="Quantity"
                      name="quantity"
                      type='quantity'
                      value={quantity}
                      onChange={(e) => {
                        setQuantity(e.target.value);
                      }}
                      variant="outlined" />

                    <TextField
                      sx={{ m: 1 }}
                      label="Order Date"
                      name="date"
                      type='date'
                      value={orderDate}
                      InputLabelProps={{
                        shrink: true,
                      }}
                      onChange={(e) => {
                        setOrderDate(e.target.value);
                      }}
                      variant="outlined" />

                    <TextField
                      sx={{ m: 1 }}
                      label="Shipping Date"
                      name="shipdate"
                      type='date'
                      value={shipDate}
                      InputLabelProps={{
                        shrink: true,
                      }}
                      onChange={(e) => {
                        setShipDate(e.target.value);
                      }}
                      variant="outlined" />


                    <Button variant="contained" sx={{ marginRight: 3, my: 3 }} color="success"
                      onClick={() => (setUpdated(!updated),
                        axios.post(`https://localhost:7050/api/Orders`, {
                          orderDate: orderDate,
                          prodId: prodID,
                          shipMode: shipMode,
                          custId: custID,
                          quantity: quantity,
                          shipDate: shipDate
                        }).then(resp => {console.log(resp)
                          setUpdated(!updated)}).catch(err => console.log(err)))}
                    >Submit</Button>
                    <Button
                      onClick={() => (setToggle(!toggle), setOrderDate(""), setProdID(""), setShipMode(""), setCustID(""), setQuantity(""), setShipDate(""))}
                      variant="contained" sx={{ marginLeft: 3, my: 3 }} color="error">Close</Button>
                  </div>)}
              </CardContent>

              <CardContent sx={{ textAlign: 'left' }}>
                {orders.map(orders => {
                  return (
                    <div className='post'>
                      <p><b>Order Date: </b> {orders.orderDate.substring(0, 10)}</p>
                      <p><b>Product ID: </b> {orders.prodId}</p>
                      <p><b>Customer ID: </b> {orders.custId}</p>
                      <p><b>Quantity: </b> {orders.quantity}</p>
                      <p><b>Shipping Date: </b> {orders.shipDate.substring(0, 10)}</p>
                      <p><b>Shipping Mode: </b> {orders.shipMode}</p>
                      <Button variant="contained" sx={{ m: 3 }} color="error"
                        onClick={() => (setUpdated(!updated),
                          axios.delete(`https://localhost:7050/api/Orders/${orders.orderDate}/${orders.custId}/${orders.prodId}`).then(resp => {console.log(resp)
                          setUpdated(!updated)}).catch(err => console.log(err)))}
                      >Remove</Button>
                      <Button variant="contained" sx={{ m: 3 }} color="secondary"
                        onClick={() => (setEditOrderDate(orders.orderDate), setEditProdID(orders.prodId), setEditCustID(orders.custId))}
                      >Edit</Button>
                    </div>
                  )
                })}
              </CardContent>
            </Card>
          </Grid>

          <Grid item xs={4} m={4} l={4}>
            <Card sx={{ width: 500, m: 2 }}>
              <CardContent sx={{ textAlign: 'center' }}>
                <Typography variant="h5" sx={{ my: 3 }}>
                  Edit Orders
                </Typography>
              </CardContent>
              <FormControl sx={{ minWidth: 200, m: 2 }}>
                <div>
                  <p><b>Order Date: </b> {editOrderDate}</p>
                  <p><b>Product ID: </b> {editProdID}</p>
                  <p><b>Customer ID: </b> {editCustID}</p>
                </div>
                <FormControl sx={{ minWidth: 200, m: 1 }}>
                  <InputLabel>Shipping Mode</InputLabel>
                  <Select
                    value={editShipMode}
                    label="Shipping Mode"
                    onChange={handleEditShipModeChange}
                  >
                    {shippings.map(shippings => {
                      return (
                        <MenuItem value={shippings.shipMode}>{shippings.shipMode}</MenuItem>
                      )
                    })}
                  </Select>
                </FormControl>
                <TextField
                  sx={{ m: 1 }}
                  label="Shipping Date"
                  name="editshipdate"
                  type='date'
                  value={editShipDate}
                  InputLabelProps={{
                    shrink: true,
                  }}
                  onChange={(e) => {
                    setEditShipDate(e.target.value);
                  }}
                  variant="outlined" />
                <TextField
                  sx={{ m: 1 }}
                  label="Quantity"
                  name="editquantity"
                  type='editquantity'
                  value={editQuantity}
                  onChange={(e) => {
                    setEditQuantity(e.target.value);
                  }}
                  variant="outlined" />
                <div>
                  <Button variant="contained" sx={{ m: 3 }} color="error"
                    onClick={clearInput}
                  >Clear</Button>
                  <Button variant="contained" sx={{ m: 3 }} color="success"
                    onClick={() => (setUpdated(!updated),
                      axios.put(`https://localhost:7050/api/Orders`, {
                        orderDate: editOrderDate,
                        prodId: editProdID,
                        shipMode: editShipMode,
                        custId: editCustID,
                        quantity: editQuantity,
                        shipDate: editShipDate
                      }).then(resp => {console.log(resp)
                      setUpdated(!updated)})
                      .catch(err => console.log(err)))}
                  >Save</Button>
                </div>
              </FormControl>
            </Card>
          </Grid>
        </Grid>
      </Center>
    </>
  );
};
export default Home;
