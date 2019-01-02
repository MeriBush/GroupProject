package testing;
import java.util.regex.Pattern;
import java.util.concurrent.TimeUnit;
import org.testng.annotations.*;
import static org.testng.Assert.*;
import org.openqa.selenium.*;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.Select;
import org.openqa.selenium.support.ui.WebDriverWait;

public class editcase {
  private WebDriver driver;
  private String baseUrl;
  private boolean acceptNextAlert = true;
  private StringBuffer verificationErrors = new StringBuffer();

  @BeforeClass(alwaysRun = true)
  public void setUp() throws Exception {
    System.setProperty("webdriver.chrome.driver", "E:/Programs/chromedriver_win32/chromedriver.exe");
	driver = new ChromeDriver();
    driver.manage().timeouts().implicitlyWait(5, TimeUnit.SECONDS);
    driver.get("http://localhost:50688/");
  }
  @Test(dataProvider = "EmployeeInput")
  public void createNewEmployee(String[] input) {
	  driver.get("http://localhost:50688/");
	    driver.findElement(By.linkText("View Employees")).click();
	    driver.findElement(By.linkText("Create New")).click();
	    WebDriverWait wait = new WebDriverWait(driver, 10);	  
		WebElement element = wait.until(ExpectedConditions.elementToBeClickable(By.id("EmpName")));
	    driver.findElement(By.id("EmpName")).clear();
	    driver.findElement(By.id("EmpName")).sendKeys(input[0]);
	    driver.findElement(By.id("EmpName")).click();
	    driver.findElement(By.id("EmpSalary")).click();
	    driver.findElement(By.id("EmpSalary")).clear();
	    driver.findElement(By.id("EmpSalary")).sendKeys(input[2]);
	    driver.findElement(By.id("EmpPosition")).click();
	    driver.findElement(By.id("EmpPosition")).clear();
	    driver.findElement(By.id("EmpPosition")).sendKeys(input[4]);
	    driver.findElement(By.id("EmpDepartment")).click();
	    driver.findElement(By.id("EmpDepartment")).clear();
	    driver.findElement(By.id("EmpDepartment")).sendKeys(input[5]);
	    driver.findElement(By.id("EmpJoinDate")).click();
	    driver.findElement(By.id("EmpJoinDate")).clear();
	    driver.findElement(By.id("EmpJoinDate")).sendKeys(input[6]);
	    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	    if(!input[1].equals("")) {
	    assertTrue(driver.findElement(By.xpath("/html/body/div[2]/form/div/div[1]/div/span/span")).getText().equals( input[1]));	
	    }
	    
	    if(!input[3].contentEquals("")) {
	    	assertTrue(driver.findElement(By.xpath("/html/body/div[2]/form/div/div[2]/div/span/span")).getText().equals( input[3]));
	    }
	    
	    if(!input[7].equals("")) {
	    	assertTrue(driver.findElement(By.xpath("/html/body/div[2]/form/div/div[5]/div/span/span")).getText().equals( input[7]));
	    }
	    
	    if(!input[8].equals("")) {
	    	assertTrue(driver.findElement(By.xpath("/html/body/div[2]/form/div/div[6]/div/span")).getText().equals( input[8]));
	    } 		    
	    
  }
  
  @DataProvider(name="EmployeeInput")
  public Object[][] EmployeeInput() {
	  return new Object[][] {
		  	{"","The Name field is required.", "","", "", "", "","The Date Of Joining field is required.",""},
		  	//{"John Smith", "","","","","","","The Date Of Joining field is required.",""},
		  	{"John Smith", "","Eighty thousand","The field Salary($) must be a number.","","","02-09-2011","",""},			  	
		  	{"Tom Wayne","","","","","","fourth of july two thousand five", "The field Date Of Joining must be a date.",""},	
		  	{"Tom Wayne","","","","","","2000", "","The value '2000' is not valid for Date Of Joining."}
			
	  };
  }
  
  @Test(dataProvider = "PositiveEmployeeInput")
  public void CreatePositiveEmployee(String[] input) {
	  driver.get("http://localhost:50688/");		
	    driver.findElement(By.linkText("View Employees")).click();
	    driver.findElement(By.linkText("Create New")).click();
	    WebDriverWait wait = new WebDriverWait(driver, 10);	  
		WebElement element = wait.until(ExpectedConditions.elementToBeClickable(By.id("EmpName")));
	    driver.findElement(By.id("EmpName")).clear();
	    driver.findElement(By.id("EmpName")).sendKeys(input[0]);
	    driver.findElement(By.id("EmpName")).click();
	    driver.findElement(By.id("EmpSalary")).click();
	    driver.findElement(By.id("EmpSalary")).clear();
	    driver.findElement(By.id("EmpSalary")).sendKeys(input[1]);
	    driver.findElement(By.id("EmpPosition")).click();
	    driver.findElement(By.id("EmpPosition")).clear();
	    driver.findElement(By.id("EmpPosition")).sendKeys(input[2]);
	    driver.findElement(By.id("EmpDepartment")).click();
	    driver.findElement(By.id("EmpDepartment")).clear();
	    driver.findElement(By.id("EmpDepartment")).sendKeys(input[3]);
	    driver.findElement(By.id("EmpJoinDate")).click();
	    driver.findElement(By.id("EmpJoinDate")).clear();
	    driver.findElement(By.id("EmpJoinDate")).sendKeys(input[4]);
	    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	    
	    assertTrue(driver.findElement(By.xpath("/html/body/div[2]/h2")).getText().equals( "All Employees"));
	    
  }
  
  @DataProvider(name="PositiveEmployeeInput")
  public Object[][] PositiveEmployeeInput() {
	  return new Object[][] {
			  {"Rob Kelly", "55000", "Programmer", "IT", "09-08-2011"},
			  {"Rob Kelly", "55000", "", "", "09-08-2011"},
			  {"Rob Kelly", "", "", "", "09-08-2011"}			  
	  };
  }
  
  @Test
  public void testEdit() throws Exception {
	  driver.get("http://localhost:50688/");
    driver.findElement(By.linkText("View Employees �")).click();
    driver.findElement(By.linkText("Edit")).click();
    driver.findElement(By.id("EmpName")).click();
    driver.findElement(By.id("EmpName")).click();
    driver.findElement(By.id("EmpName")).clear();
    driver.findElement(By.id("EmpName")).sendKeys("edit1");
    driver.findElement(By.id("EmpSalary")).click();
    driver.findElement(By.id("EmpSalary")).clear();
    driver.findElement(By.id("EmpSalary")).sendKeys("150000");
    driver.findElement(By.id("EmpPosition")).click();
    driver.findElement(By.id("EmpPosition")).clear();
    driver.findElement(By.id("EmpPosition")).sendKeys("dev");
    driver.findElement(By.id("EmpDepartment")).click();
    driver.findElement(By.id("EmpDepartment")).clear();
    driver.findElement(By.id("EmpDepartment")).sendKeys("IT");
    driver.findElement(By.id("EmpJoinDate")).click();
    driver.findElement(By.id("EmpJoinDate")).click();
    driver.findElement(By.id("EmpJoinDate")).clear();
    driver.findElement(By.id("EmpJoinDate")).sendKeys("10/15/1999");
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
    assertEquals(driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::td[2]")).getText(), "edit1");
    assertEquals(driver.findElement(By.xpath("(.//td[contains(text(),'150000')])")).getText(), "150000");
  }
  @Test
  public void testEditAlternative() throws Exception {
	  driver.get("http://localhost:50688/");
    driver.findElement(By.linkText("View Employees �")).click();
    driver.findElement(By.linkText("Edit")).click();
    driver.findElement(By.id("EmpSalary")).click();
    driver.findElement(By.id("EmpSalary")).clear();
    driver.findElement(By.id("EmpSalary")).sendKeys("asd");
    driver.findElement(By.id("EmpJoinDate")).click();
    driver.findElement(By.id("EmpJoinDate")).clear();
    driver.findElement(By.id("EmpJoinDate")).sendKeys("asd");
    driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
    assertEquals(driver.findElement(By.xpath("(.//span[@for='EmpSalary'])")).getText(), "The field Salary($) must be a number.");
    assertEquals(driver.findElement(By.xpath("(.//span[@for='EmpJoinDate'])")).getText(), "The field Date Of Joining must be a date.");
  }
  @Test
  public void TheEditAlternativeTestDateChecker() throws Exception
  {
	  driver.get("http://localhost:50688/");
	            driver.findElement(By.linkText("View Employees �")).click();
	            driver.findElement(By.linkText("Edit")).click();
	            driver.findElement(By.id("EmpJoinDate")).click();
	            driver.findElement(By.id("EmpJoinDate")).clear();
	            driver.findElement(By.id("EmpJoinDate")).sendKeys("asd"); //test for characters
	            driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	            assertEquals("The field Date Of Joining must be a date.", driver.findElement(By.xpath("(.//span[@for='EmpJoinDate'])")).getText());

	            driver.findElement(By.id("EmpJoinDate")).click();
	            driver.findElement(By.id("EmpJoinDate")).clear();
	            driver.findElement(By.id("EmpJoinDate")).sendKeys("!@#$"); //test for special characters
	            driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	            assertEquals("The field Date Of Joining must be a date.", driver.findElement(By.xpath("(.//span[@for='EmpJoinDate'])")).getText());

	            driver.findElement(By.id("EmpJoinDate")).click();
	            driver.findElement(By.id("EmpJoinDate")).clear();
	            driver.findElement(By.id("EmpJoinDate")).sendKeys("1111"); //test for invalid date object
	            driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	            assertEquals("The value '1111' is not valid for Date Of Joining.", driver.findElement(By.xpath("(.//span[@class='field-validation-error text-danger'])")).getText());

	            driver.findElement(By.id("EmpJoinDate")).click();
	            driver.findElement(By.id("EmpJoinDate")).clear();
	            driver.findElement(By.id("EmpJoinDate")).sendKeys("11/11/111111"); //test for invalid date object
	            driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	            driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	            assertEquals("The value '11/11/111111' is not valid for Date Of Joining.", driver.findElement(By.xpath("(.//span[@class='field-validation-error text-danger'])")).getText());
	        }

  @Test
  public void TheFailingEditDateTestCase() throws Exception
  {
	  driver.get("http://localhost:50688/");
	            driver.findElement(By.linkText("View Employees �")).click();
	            driver.findElement(By.linkText("Edit")).click();
	            driver.findElement(By.id("EmpJoinDate")).click();
	            driver.findElement(By.id("EmpJoinDate")).clear();
	            driver.findElement(By.id("EmpJoinDate")).sendKeys("11/11/1111"); //test for characters
	            driver.findElement(By.xpath("(.//*[normalize-space(text()) and normalize-space(.)='Date Of Joining'])[1]/following::input[2]")).click();
	            assertEquals("The field Date Of Joining must be a date.", driver.findElement(By.xpath("(.//span[@for='EmpJoinDate'])")).getText());
  }

  @AfterClass(alwaysRun = true)
  public void tearDown() throws Exception {
    driver.quit();
    String verificationErrorString = verificationErrors.toString();
    if (!"".equals(verificationErrorString)) {
      fail(verificationErrorString);
    }
  }


  }

