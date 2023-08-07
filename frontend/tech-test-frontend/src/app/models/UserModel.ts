export interface UserModel {
    id: number,
    name: string,
    lastName: string,
    email: string,
    birthDate: string,
    scholarityId?: number,
    schoolHistoryId?: number,
    scholarity?: string;
    schoolHistoryName?: string,
    schoolHistoryFormat?: string,
    schoolHistoryFile?: string
    
}