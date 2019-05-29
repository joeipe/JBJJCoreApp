export interface ClassType {
    id: number;
    isDirty: boolean;
    name: string;
}

export interface TimeTable {
    id: number;
    isDirty: boolean;
    dayofWeek: string;
    startTimeHr: number;
    startTimeMin: number;
    endTimeHr: number;
    endTimeMin: number;
    classTypeId: number;
    classType: ClassType;
}

export interface Grade {
    id: number;
    isDirty: boolean;
    name: string;
}

export interface Person {
    id: number;
    isDirty: boolean;
    firstName: string;
    lastName: string;
    gradeId: number;
    stripe: number;
    grade: Grade;
}
