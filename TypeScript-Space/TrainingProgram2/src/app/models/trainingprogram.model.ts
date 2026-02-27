export interface TrainingProgram{
    id: number;
    programName: string;
    department: string;
    description: string;
    isActive: boolean;
    startDate: string;
    endDate: string;
    trainerName: string;
    participantCount: number;
}