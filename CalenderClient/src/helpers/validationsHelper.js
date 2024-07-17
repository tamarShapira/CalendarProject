export const  requiredValidator = value => {
    if (value.length < 1) return "required";
    return false;
};
export const emailValidator = value => {
    if (value.length < 1) return "required";
    if (!/^[a-zA-Z0-9._:$!%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]+$/.test(value))
        return "Invalid email address";
    return false;
};

export const tzValidator = value => {
    if (value.length < 1) return "required";
    if (!/[0-9]/.test(value) || value.length != 9)
        return "Invalid tz";
    return false;
};

export const phoneValidator = value => {
    if (value.length < 1) return "required";
    if (!/[0-9]{9}/.test(value) || (value.length != 9 && value.length != 10))
        return "Invalid phone";
    return false;
};