describe('App shopping list, test e2e', () => {
  beforeEach(() => {
    cy.visit('http://localhost:5173/');
  });

  it('contains all the element', () => {
    cy.get('input[placeholder="Nouvel article"]').should('be.visible');
    cy.get('.addInput').type('activité 1');
    cy.get('.addButton').click();

    cy.get('.addInput').type('activité 2');
    cy.get('.addButton').click();

    cy.get('.container').find('button').should('have.length', 2);

    cy.contains('activité 1').should('be.visible');
    cy.contains('activité 2').should('be.visible');
  });

  it('should display "Aucune tâche" at the start ', () => {
    cy.contains(/aucun/i).should('be.visible');
  });

  it('should delete an element after clicking delete button', () => {
    cy.get('.addInput').type('activité 1');
    cy.get('.addButton').click();

    cy.get('.deleteButton').first().click();

    cy.get('.container').find('button').should('have.length', 0);

    cy.contains(/aucun/i).should('be.visible');
  });
});
