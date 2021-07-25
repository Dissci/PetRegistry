import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Detail } from './Detail';
import { Button, ButtonToolbar } from 'react-bootstrap';

export class Person extends Component {

    constructor(props) {
        super(props);
        this.state = { persons: [], addModalShow: false, detailModalShow: false }
    }

    refreshList() {
        fetch('api/person')
            .then(response => response.json())
            .then(data => {
                this.setState({ persons: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { persons, pID, pName, pSurname} = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let detailModalClose = () => this.setState({ detailModalShow: false });
        return (
            <div >
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>#</th>
                            <th>Name</th>
                            <th>Surname</th>
                            <th>Option</th>
                        </tr>
                    </thead>
                    <tbody>
                        {persons.map(person =>
                            <tr key={person.personID}>
                                <td>Checkbox</td>
                                <td>{person.name}</td>
                                <td>{person.surname}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={() => this.setState({
                                                detailModalShow: true,
                                                pID: person.personID, pName: person.name, pSurname: person.surname
                                            })}>
                                            Show Details
                                        </Button>
                                        <Detail show={this.state.detailModalShow}
                                            onHide={detailModalClose}
                                            pID={pID}
                                            pName={pName}
                                            pSurname={pSurname}/>
                                    </ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>
            </div>
        )
    }
}