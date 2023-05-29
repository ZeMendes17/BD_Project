CREATE INDEX idx_item_store ON Project.ITEM(StoreURL);

CREATE INDEX idx_item_order ON Project.ITEM_ORDER(ItemID);

CREATE INDEX idx_item_supplies ON Project.SUPPLIES(ItemID);

CREATE INDEX idx_order_costumer ON Project.[ORDER](CostumerNIF);

CREATE INDEX idx_supplier_id ON Project.SUPPLIER(ID);

CREATE INDEX idx_staff_store ON Project.STAFF(StoreURL);

CREATE INDEX idx_manages_store ON Project.MANAGER(StoreURL);

CREATE INDEX idx_transport_number ON Project.TRANSPORT(TransportNumber);
