import React from "react";
import { MemoryRouter } from "react-router-dom";
import { configure, mount } from "enzyme";
import Product from "../../components/codeChallenge/Product";
import App from "../../App";
import Adapter from "@wojtekmaj/enzyme-adapter-react-17";
import productService from "../../components/codeChallenge/services/productService";

configure({ adapter: new Adapter() });

const axios = require("axios");
jest.mock("axios");
describe("React Forms #1", () => {
  it("App.jsx has a route for Product", () => {
    const wrapper = mount(
      <MemoryRouter initialEntries={["/product"]}>
        <App />
      </MemoryRouter>
    );
    expect(wrapper.find(Product)).toHaveLength(1);
  });

  let wrap;
  beforeEach(() => {
    wrap = mount(<Product />);
  });
  afterEach(() => {
    wrap.update();
  });

  it("The form element is rendered. HINT: the element should be lowercase", () => {
    expect(wrap.exists("form")).toEqual(true);
  });

  it("form-group classes exist on the divs around each form item", () => {
    expect(wrap.exists("div.form-group")).toEqual(true);
  });

  it("An input for name exists on the form. HINT: do you have an id property?", () => {
    expect(wrap.containsMatchingElement(<input id="name" />)).toBeTruthy();
  });

  it("An input for manufacturer exists on the form. HINT: do you have an id property?", () => {
    expect(
      wrap.containsMatchingElement(<input id="manufacturer" />)
    ).toBeTruthy();
  });

  it("An input for description exists on the form. HINT: do you have an id property?", () => {
    expect(
      wrap.containsMatchingElement(<input id="description" />)
    ).toBeTruthy();
  });

  it("An input for cost exists on the form. HINT: do you have an id property?", () => {
    expect(wrap.containsMatchingElement(<input id="cost" />)).toBeTruthy();
  });

  it("'Submit' button exists. HINT: Button text should say 'Submit'", () => {
    expect(wrap.containsMatchingElement(<button>Submit</button>)).toBeTruthy();
  });

  it("'Submit' button includes an onClick handler", () => {
    const buttonWrap = wrap.find("button").at(0);
    expect(buttonWrap.props().onClick).toEqual(expect.any(Function));
  });

  it("POST endpoint exists in service file. HINT: Service method should be called 'addProduct'", () => {
    const mockedResponse = {
      data: {},
      config: {},
      headers: {},
      request: "",
      status: 201,
      statusText: "Created",
    };

    axios.post.mockResolvedValue(mockedResponse);
    productService.addProduct();
  });

  it("addProduct in axios service file works correctly", () => {
    axios.mockResolvedValue();

    const mockProduct = {
      name: "Rocktopus",
      manufacturer: "3D Printed",
      description: "A weird 3D combo of The Rock and an octopus",
      cost: 30,
    };

    productService.addProduct(mockProduct);

    expect(axios).toBeCalledWith({
      crossdomain: true,
      data: mockProduct,
      url: "https://api.remotebootcamp.dev/api/entities/products",
      headers: {
        "Content-Type": "application/json",
      },
      withCredentials: true,
      method: "POST",
    });
  });

  it("Submit button calls addProduct in service file", () => {
    axios.mockResolvedValue();
    const buttonWrap = wrap.find("button").at(0);

    buttonWrap.simulate("click");
    expect(axios).toHaveBeenCalled();
  });
});
