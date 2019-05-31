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

export interface Outcome {
    id: number;
    isDirty: boolean;
    name: string;
}

export interface Attendance {
    id: number;
    isDirty: boolean;
    timeTableId: number;
    attendedOn: string;
    techniqueOfTheDay: string;
    timeTableClassAttended: TimeTableClassAttended;
}

export interface AttendanceDetailed {
    id: number;
    isDirty: boolean;
    timeTableId: number;
    attendedOn: Date;
    techniqueOfTheDay: string;
    timeTableClassAttended: TimeTableClassAttended;
    sparringDetails: SparringDetails[];
}

export interface SparringDetails {
    id: number;
    isDirty: boolean;
    attendanceId: number;
    personId: number;
    outcomeId: number;
    techniqueUsed: string;
    attendance: Attendance;
    personSparringPartner: PersonSparringPartner;
    outcome: Outcome;
}

export interface TimeTableClassAttended {
    id: number;
    dayofWeek: string;
    startTimeHr: number;
    startTimeMin: number;
    endTimeHr: number;
    endTimeMin: number;
    classType: string;
}

export interface PersonSparringPartner {
    id: number;
    fullName: string;
    stripe: number;
    grade: string;
}
