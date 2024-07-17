import React from "react";
import { Typography, Container, Grid, Box } from "@mui/material";
import CalendarIcon from "@mui/icons-material/CalendarToday"; // Import an icon from Material-UI icons

const About = () => {
  return (
    <Container maxWidth="md">
      <Grid container spacing={4} justifyContent="center">
        {/* Header section with icon/image */}
        <Grid item xs={12} textAlign="center">
          <Box mt={6} textAlign="center">
            <CalendarIcon style={{ fontSize: 80, marginTop: "20px" }} />
          </Box>
          <Box mt={4} textAlign="center">
            <Typography variant="h4" gutterBottom color="primary">
              אודות קלנדר
            </Typography>
          </Box>
        </Grid>
        {/* Main content area */}
        <Grid item xs={12}>
          <Typography variant="body1" gutterBottom>
            אתר לעיצוב לוח שנה אישי-משפחתי. הלוח מעוצב אוטומטית על ידי האתר
            על פי התמונות והתאריכים שהמשתמש מכניס.
          </Typography>
          {/* <Typography variant="h6" gutterBottom>
            מטרות המערכת
          </Typography> */}
          <Typography variant="body1">
            <ul>

              כיום, כאשר משפחה רוצה ליצור לוח משפחתי
              משלה למטרת זכירת התאריכים וגיבוש בני המשפחה-הדבר דורש זמן רב ,
              על מנת לקבל את הלוח המשתמש נדרש להכניס
              בעצמו את התמונות והתאריכים, זוהי מלאכה מורכבת ודורשת ידע
              והתמצאות במחשב.
              לכן חשבנו על פתרון קל יותר לחוויה משפחתית
              גדולה יותר, איך להפוך את הרצון הטוב הזה – לזכור את התאריכים
              החשובים ליקרים לנו בקלות ומהירות יותר.
              גם אנשים המתקשים בטכנולגיה יוכלו בצורה
              קלה ופשוטה לעצב באתר לוח אישי מאחר שהדבר היחיד שנדרש
              מהמשתמש הינו הכנסת נתונים לתיבות קלט-דבר
              יחסית פשוט וקל.
              כדי להגדיל את החויה המשפחתית הוספנו
              אפשרות להעלאת תמונות אישיות,וכן ליצירת לוח אישי עבור כל משפחה
              גרעינית מתוך משפחה  מורחבת
              אנו מקוות שתמצאו את האתר נוח, נגיש
              ושימושי בשבילכם ובשביל המשפחה היקרה שלכם
              כי משפחה זה מתנה שאין לה תחליף!
            </ul>
          </Typography>
        </Grid>
      </Grid>
    
        </Container>

        );
};

        export default About;
