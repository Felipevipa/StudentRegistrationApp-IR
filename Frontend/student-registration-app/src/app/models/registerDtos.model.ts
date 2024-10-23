export interface RegisterDto {
    studentName: string;
    courses: CourseRegisterDto[];
}

export interface CourseRegisterDto {
    courseId: string;
    courseName: string;
    credits: number;
    teacherId: string;
    teacherName: string;
    // students: string[]
}