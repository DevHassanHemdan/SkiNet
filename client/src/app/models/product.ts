export interface IProduct {
  id: number;
  name: string;
  description: string;
  price: number;
  pictureUrl: string;
  productType: string;
  productBrand: string;
  createdOn: Date;
  createdBy: string;
  updatedOn: Date;
  updatedBy: string;
  deletedOn: Date;
  deletedBy: string;
}
