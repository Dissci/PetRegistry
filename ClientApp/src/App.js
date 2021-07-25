import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Person } from './components/Person';
import { Detail } from './components/Detail';

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
            <Route exact path='/' component={Person} />
            <Route exact path='/detail' component={Detail} />
      </Layout>
    );
  }
}
