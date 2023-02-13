let validations = document.querySelectorAll('span.text-danger');
// validations.forEach(v => setTimeout(() => $(v).fadeOut(750), 3000));

let timeOut = 800
for (let i = 0; i < validations.length; i++)
{
    timeOut +=200;
    setTimeout(() => $(validations[i]).fadeOut(750), timeOut);
}