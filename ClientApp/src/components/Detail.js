import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';
import { Table } from 'react-bootstrap';
import { ButtonToolbar } from 'react-bootstrap';
export class Detail extends Component {
    constructor(props) {
        super(props);
        this.state = { id: this.props.pID }
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        
    }

    refreshList() {
        const pathID = this.state.id;
        fetch('api/person/detail/1')
            .then(response => response.json())
            .then(data => {
                this.setState({ detail: data });
            });
    }

    handleClick(e) {
        this.feed(e.animal.id);
    }

    feed(petID) {
        const response = fetch('api/animal/feed/' + petID);
        alert('HELLO, ${ petID }');
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    render() {
        const { detail } = this.state;
        const { pName, pSurname } = this.props;
        return (
            <div className="container">

                <Modal
                    {...this.props}
                    size="lg"
                    aria-labelledby="contained-modal-title-vcenter"
                    centered
                >
                    <Modal.Header clooseButton>
                        <Modal.Title id="contained-modal-title-vcenter">{pName} {pSurname}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>

                        <Row>
                            <Col sm={6}>
                                <Table className="mt-4" striped bordered hover size="sm">
                                    <thead>
                                        <tr>
                                            <th>Name</th>
                                            <th>FeedingCount</th>
                                            <th>Age</th>
                                            <th>Option</th>
                                        </tr>
                                    </thead>
                                    
                                </Table>
                            </Col>
                        </Row>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>

                </Modal>

            </div>
        )
    }

}