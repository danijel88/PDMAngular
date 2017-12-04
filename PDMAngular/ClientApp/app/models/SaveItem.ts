import { Status } from "./status";

export interface SaveItem {
    id: number;
    internalCode: string;
    description: string;
    band: number;
    enter: number;
    exit: number;
    thickness: number;
    elastic: boolean;
    madeBy: string;
    color: string;
    name: string;
    itemTypeId: number;
    machineTypeId: number;
    status: number;
}