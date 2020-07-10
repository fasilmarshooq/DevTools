import React from "react";
import { Modal, Button } from "react-bootstrap";

const PopUpModal = (props) => {
  return (
    <Modal
      {...props}
      size="lg"
      aria-labelledby="contained-modal-title-vcenter"
      centered
      scrollable
    >
      <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
          {props.modalHeader}
        </Modal.Title>
      </Modal.Header>
      <Modal.Body>{props.modalBody}</Modal.Body>
      <Modal.Footer>
        <Button onClick={props.handleModalFooterButtonClick}>
          {props.modalFooterButtonLabel}
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default PopUpModal;
